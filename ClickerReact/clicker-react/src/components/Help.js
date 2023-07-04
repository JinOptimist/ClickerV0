import { Form, useLoaderData, useParams } from "react-router-dom";

function Help() {
  const { smile } = useParams();

  return (
    <div>
      Help for {smile}
    </div>
  );
}

export default Help;
